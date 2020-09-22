using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ButtonDeckClient.Workflows
{
    public abstract class Command
    {
        public abstract void Execute(ICommandContext commandContext);
    }
}
