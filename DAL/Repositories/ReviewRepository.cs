﻿using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(Context context)
            : base(context)
        { }
    }
}
