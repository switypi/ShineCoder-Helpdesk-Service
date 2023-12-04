namespace ShineCoder_Helpdesk.Core.Helpers
{
	public interface IValidator
	{
		IEnumerable<string> Validate(object item);
	}
}