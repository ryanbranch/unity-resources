

## A Note

**unity-resources** is not a single coherent project. It's a variety of code and non-code files which span many projects. I've designed these files to be widely useful in a variety of cases, regardless of whether Unity is being used to make a game at all.

The code in **unity-resources** isn't guaranteed to run in any given scenario, since there are inevitably drag-and-drop-type steps that need to be taken external to scripting. Most of this code likely serves best as an example to follow in your own implementations, as opposed to trying to use it all directly in this state.

# unity-resources

In June 2020 I began attempting to learn Unity as a way to create data visualizations for scientific research. I have been focusing on a script-based approach instead of using the drag-and-drop functionalities wherever possible, and in doing so I've created some scripts which seem to hold general utility for future projects. A summary of what I've created so far is below:

## rsg1

**rsg1** is my most widely scoped set of C# resources with a scripting-only focus.
See the [rsg1 README](projects/rsg1/README.md) for more details.


## Acknowledgments

The following people provided help in terms of things like sample code and answers to questions posted online:

* **[Kyle W Banks](https://github.com/KyleBanks)**, for his [blog post](https://kylewbanks.com/blog/unity-2d-detecting-gameobject-clicks-using-raycasts) about detecting GameObject clicks in Unity using 2D raycasting
* **[Ilya Suzdalnitski](https://github.com/suzdalnitski)**, for his [StackOverflow answer](https://stackoverflow.com/a/28957199) about setting the *isReadable* property of a *Texture2D* object through script
* **GitHub user** [**PurpleBooth**](https://github.com/PurpleBooth) for the [template](https://gist.github.com/PurpleBooth/109311bb0361f32d87a2) that I used in creating this README

I'm also thankful to the following specific resources which were referenced during development:

* [**Unity Learn**](https://learn.unity.com/), especially the following tutorial series:
  * [*"Unity C# Survival Guide"*](https://learn.unity.com/course/unity-c-survival-guide) by Jonathan Weinberger
* The [**Unify Wiki**](http://wiki.unity3d.com/index.php/Main_Page), especially the following articles:
  * [*"Choosing the right collection type"*](https://wiki.unity3d.com/index.php/Choosing_the_right_collection_type)
