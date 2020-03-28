using SecretSanta.Data.EF.Repositories.FeedbackRepository;
using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services.FeedbackService
{
    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public void GetInTouch(FeedbackForm feedback)
        {
            _feedbackRepository.SendFeedback(feedback);
        }
    }
}
