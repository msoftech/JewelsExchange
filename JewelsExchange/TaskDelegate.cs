using System;
namespace JewelsExchange
{
	public interface TaskDelegate
	{
		void taskCompletionResult();
		//void taskCompletionResult(ArrayList<HashMap<String, String>> result, String MethodName);
	}
}
