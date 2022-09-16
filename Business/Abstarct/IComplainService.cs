using Common.DTOs;
using Common.Result;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IComplainService
    {

        BCResponse Add(ComplainDto ComplainDto);
        BCResponse Delete(int complainId);
        BCResponse Update( ComplainDto complainDto);

        BCResponse GetAll(Expression<Func<Complain, bool>> filter = null);
        BCResponse GetComplainByUserId(int userId);
        BCResponse GetById(int id);

    }


}
