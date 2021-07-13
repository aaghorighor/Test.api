namespace Test.Interface
{
    using Test.Logger.Services.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFileService
    {
        Task WriteLineAsync(Message message);
    }
}
