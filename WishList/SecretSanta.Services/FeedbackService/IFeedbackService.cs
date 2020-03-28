using SecretSanta.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Services.FeedbackService
{
    public interface IFeedbackService
    {
        void GetInTouch(FeedbackForm feedback);
    }
}
