using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP.Infrastructure.Helpers
{
   
        public static class DbExceptionHelper
        {
            public static bool IsUniqueConstraintViolation(DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx)
                {
                    return sqlEx.Number == 2627 || sqlEx.Number == 2601;
                }
                return false;
            }

            public static bool IsForeignKeyViolation(DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx)
                {
                    return sqlEx.Number == 547;
                }
                return false;
            }
        }

    
}
