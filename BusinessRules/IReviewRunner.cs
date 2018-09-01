﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
    public interface IReviewRunner
    {
        Task<ReviewResult> Run<Model, Context>(Model model, Context context);
    }
}
