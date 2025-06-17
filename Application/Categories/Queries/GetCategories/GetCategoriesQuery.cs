using Application.Abstractions.Messaging;
using Domain.Entities;

namespace Application.Categories.Queries.GetCategories;

public sealed record GetCategoriesQuery() : IQuery<List<Category>>;
