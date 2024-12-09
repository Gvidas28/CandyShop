using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyShop.Model.Entities;

public sealed class DatabaseException : Exception
{
    public DatabaseOperationResult Result { get; set; }

    public DatabaseException(DatabaseOperationResult result) : base(result.ToString())
    {
        Result = result;
    }
}

public enum DatabaseOperationResult
{
    UpdateUnsuccesful = 1
}