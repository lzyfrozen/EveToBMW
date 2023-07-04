using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveToBMW
{
    public interface IEdiRequest
    {
        TResult Feedback<TResult>(FeedbackDto dto) where TResult : class;

        TResult Oauth<TResult>(FeedbackDto dto) where TResult : class;
    }
}
