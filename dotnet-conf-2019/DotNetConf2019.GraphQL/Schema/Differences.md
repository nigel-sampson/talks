| functionality | Mark's EF generated code | Nigel's Code | Star Wars code |
| ------------- | ------------- | ----- | ----- |
| getters and setters(DB) | Models folder | Data folder | Repository folder |
| graphql types | NA | Schema folder(e.g. Schema/PostType.cs) | One folder per type (e.g. Reviews/Review.cs, Characters/Character.cs) |
| resolvers | NA | Schema Folder in Query.cs and Mutation.cs | One folder per type (same location as graphql types, e.g. Reviews/ReviewQuery.cs, Reviews/ReviewMutation.cs) |
