﻿using Abstraction.Validation;
using ArticleService.Abstraction.Command;
using FluentValidation;

namespace ArticleService.Abstraction.Validation
{
    public class CreateArticleCommandValidator : BaseValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.ArticleContent).NotEmpty();
            RuleFor(x => x.StarCount).NotEmpty();
            RuleFor(x => x.PublishDate).NotNull().NotEmpty();
        }
    }
}