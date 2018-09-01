using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRules
{
    public interface IReviewRunner
    {
        ReviewResult Run<Model, Context>(Model model, Context context);
    }
}
