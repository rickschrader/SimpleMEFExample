
namespace Contracts
{
    public interface IStringMutator
    {
        string ComponentDescription { get; }
        string MutateString(string s);
    }

}