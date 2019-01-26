using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Core.Entities
{
    public interface IWindow
    {
        void Initialize(IRoot root);

        Task Show(CancellationToken cancellationToken);

        Task Hide(CancellationToken cancellationToken);

    }
}
