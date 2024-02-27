using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain.Interfaces
{
    public interface IStepRepository
    {
        Task CreateStep(Domain.Entities.Step step);

        Task <IEnumerable<Domain.Entities.Step>> GetAllStepsByEncodedTitle(string encodedTitle);
    }
}
