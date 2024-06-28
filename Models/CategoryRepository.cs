namespace CrudOperationsDotNet8.Models
{
	public static class CategoryRepository
	{
		private static List<Category> _categories = new List<Category>()
		{
			new Category {CategoryId=1,Name="Beverages",Description="Beverages"},
			new Category{CategoryId=2,Name="Bakery",Description="Bakery"},
			new Category{CategoryId=3,Name="Meat",Description="Meat"}
		};


		public static void AddCategory(Category category)
		{
			var MaxId=_categories.Max(c => c.CategoryId);
			category.CategoryId = MaxId+1;
			_categories.Add(category);
		}

		public static List<Category> GetCategories()=>_categories;

		public static Category? GetCategoryById(int Categoryid)
		{
			var category = _categories.FirstOrDefault(c => c.CategoryId == Categoryid);
			if(category!=null)
			{
				return new Category
				{
					CategoryId = category.CategoryId,
					Name = category.Name,
					Description = category.Description,
				};
			}
			return null;
		}


		public static void UpdateCategory(int categoryid,Category category)
		{
			if (categoryid != category.CategoryId) return;

			var categoryToUpdate= _categories.FirstOrDefault(x => x.CategoryId == categoryid);
			if (categoryToUpdate != null)
			{
				categoryToUpdate.Name = category.Name;
				categoryToUpdate.Description = category.Description;
			}
		}

		public static void DeleteCategory(int categoryid)
		{
			var category=_categories.FirstOrDefault(x=>x.CategoryId == categoryid);

			if (category != null)
			{
				_categories.Remove(category);
			}

		}







	}
}
