﻿using System.Threading;
using System.Threading.Tasks;
using Abstraction.Exceptions;
using Abstraction.Handler;
using ReviewService.Abstraction.Command;
using ReviewService.Domain.Entities;
using ReviewService.Infrastructure.Context;
using Data.UnitOfWork;
using MediatR;

namespace ReviewService.Application.CommandHandlers
{
    public class UpdateReviewCommandHandler : ICommandHandler<UpdateReviewCommand, Unit>
    {
        private readonly IUnitOfWork<ReviewDbContext> _unitOfWork;
        

        public UpdateReviewCommandHandler(IUnitOfWork<ReviewDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.GetRepository<Review>()
                .GetFirstAsync(x => x.ReviewId == request.ReviewId, cancellationToken).ConfigureAwait(false);
            
            if (review == null)
            {
                throw new BusinessException($"Record does not exist. ReviewId: {request.ReviewId} ");
            }
            review.Update(request.ReviewId, request.Reviewer, request.ReviewContent);
            return Unit.Value;
        }
    }
}