| Functionality | Mark's EF Generated Code | Nigel's Code | Star Wars Code | [graphql-code-generator Java/C# Code](https://github.com/dotansimha/graphql-code-generator) |
| ------------- | ------------- | ----- | ----- | ----- |
| DB Getters and Setters(DB stuff and types) | Models folder | Data folder | Repository folder |  NA |
| graphql types | NA | Schema folder(e.g. Schema/PostType.cs) | One folder per type (e.g. Reviews/Review.cs, Characters/Character.cs) | Types |
| resolvers | NA | Schema Folder in Query.cs and Mutation.cs | One folder per type (same location as graphql types, e.g. Reviews/ReviewQueries.cs, Reviews/ReviewMutations.cs) | Resolvers |
