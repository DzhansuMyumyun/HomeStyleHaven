﻿using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.DataAccsess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, HomeStyleHavenContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new HomeStyleHavenContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}