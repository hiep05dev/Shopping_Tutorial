using Shopping_Tutorial.DTO.Request;
using Shopping_Tutorial.Models;

namespace Shopping_Tutorial.Repository.RepositoryMethod
{
	public interface FeedBackRepository
	{
		public Task<FeedBackModel> FeedBack(FeedBackRequest feedBackRequest);

		public Task<IEnumerable<FeedBackModel>> GetAllFeedBack();
	}
}
