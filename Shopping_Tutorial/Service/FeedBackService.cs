using Microsoft.EntityFrameworkCore;
using Shopping_Tutorial.DTO.Request;
using Shopping_Tutorial.Models;
using Shopping_Tutorial.Repository;
using Shopping_Tutorial.Repository.RepositoryMethod;

namespace Shopping_Tutorial.Service
{
	public class FeedBackService : FeedBackRepository
	{
		private readonly DataContext _context;

		public FeedBackService(DataContext context)
		{
			_context = context;
		}

		public async Task<FeedBackModel> FeedBack(FeedBackRequest feedBackRequest)
		{

			var feedBackModel = new FeedBackModel
			{
             UserId = feedBackRequest.UserId,
			 Comment = feedBackRequest.Comment,
			};
			_context.FeedBacks.Add(feedBackModel);
			await _context.SaveChangesAsync();	

			return feedBackModel;
		}

		public async Task<IEnumerable<FeedBackModel>> GetAllFeedBack()
		{
			return await _context.FeedBacks.Include(p => p.User).ToListAsync();
		}
	}
}
