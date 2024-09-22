using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfGenerate.Service.Interface
{
    public interface IPDF
    {
        Task<byte[]?> DownloadPdfAsync(CancellationToken cancellationToken);
    }
}
