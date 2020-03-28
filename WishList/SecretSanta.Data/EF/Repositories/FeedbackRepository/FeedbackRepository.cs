using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.EF.Repositories.FeedbackRepository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public void SendFeedback(FeedbackForm feedbackFrom)
        {
            using (SantaContext context = new SantaContext())
            {
                context.FeedbackForms.Add(feedbackFrom);
                context.SaveChanges();
            }
        }
    }
}
