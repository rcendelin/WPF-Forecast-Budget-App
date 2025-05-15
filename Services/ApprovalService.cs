using System;
using System.Linq;
using ForecastBudgetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForecastBudgetApp.Services
{
    public class ApprovalService
    {
        private readonly DatabaseContext _context;

        public ApprovalService()
        {
            _context = new DatabaseContext();
        }

        public void SubmitPlan(int planId, string comments)
        {
            var plan = _context.Plans.Find(planId);
            if (plan != null)
            {
                plan.Comments = comments;
                plan.IsSubmitted = true;
                _context.SaveChanges();
            }
        }

        public void ApprovePlan(int planId, string approvedBy)
        {
            var plan = _context.Plans.Find(planId);
            if (plan != null)
            {
                plan.IsApproved = true;
                plan.ApprovedBy = approvedBy;
                _context.SaveChanges();
            }
        }

        public void RejectPlan(int planId, string comments)
        {
            var plan = _context.Plans.Find(planId);
            if (plan != null)
            {
                plan.Comments = comments;
                plan.IsSubmitted = false;
                _context.SaveChanges();
            }
        }
    }
}
