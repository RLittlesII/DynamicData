using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace DynamicData
{
	/// <summary>
	/// Dodgy and smelly internal means off accessing the inner list of the changeset.
	/// Not indended for public use as consequences of tampering with the items
	/// can be dire in the wrong hands
	///
	/// It will do for the first iteration. If I cannot think of something better
	/// I will remove the above comment and pretend all is good in the world.
	/// </summary>
	internal interface IChangeSetListAccessor<TObject, TKey>
	{
		List<Change<TObject, TKey>> Items { get; }
	}
}