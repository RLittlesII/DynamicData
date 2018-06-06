using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using DynamicData.Binding;
using DynamicData.Kernel;
using DynamicData.Tests.Domain;
using FluentAssertions;
using Xunit;

namespace DynamicData.Tests.Cache
{
	public class SortWithResetFixture : IDisposable
	{
		private readonly ISourceCache<Person, string> _source;
		private readonly SortedChangeSetAggregator<Person, string> _results;
		private readonly RandomPersonGenerator _generator = new RandomPersonGenerator();
		private readonly IComparer<Person> _comparer;


		public SortWithResetFixture()
		{
			_comparer = SortExpressionComparer<Person>.Ascending(p => p.Name).ThenByAscending(p => p.Age);

			_source = new SourceCache<Person, string>(p => p.Key);
			_results = new SortedChangeSetAggregator<Person, string>
			(
				_source.Connect().Sort(_comparer)
			);
		}

		public void Dispose()
		{
			_source.Dispose();
			_results.Dispose();
		}

		[Fact]
		public void CrossResetThreshoold()
		{
			var people = _generator.Take(150).ToArray();
			_source.AddOrUpdate(people.Take(10));

			//add items which crosses the default threshold of 50
			_source.AddOrUpdate(people.Skip(10));


			var list = new ObservableCollectionExtended<Person>(people.OrderBy(p => p, _comparer));
			var adaptor = new SortedObservableCollectionAdaptor<Person, string>();
			adaptor.Adapt(_results.Messages.Last(), list);

			var shouldbe = _results.Messages.Last().SortedItems.Select(p => p.Value).ToList();
			list.ShouldAllBeEquivalentTo(shouldbe);
		}


	}
}