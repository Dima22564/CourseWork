#nullable enable
using System;
using JetBrains.Annotations;

namespace ERP.Services.Exceptions
{
    public class ModelNotFoundException : Exception
    {
        public ModelNotFoundException([CanBeNull] string? message) : base(message)
        {
        }
    }
}