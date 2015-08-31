Getting started
--------------------------------------------------
Follow the examples below or open the sample project to see how to use Cheeseknife.

Usage - Activity
---------------------
```csharp
public class ExampleActivity : Activity {
	[InjectView(Resource.Id.myTextView)]
	TextView textView;
	
	[InjectOnClick(Resource.Id.myButton)]
	void OnClickMyButton(object sender, EventArgs e) {
		// This code will run when the button is clicked ...
	}

	protected override void OnCreate(Bundle bundle) {
		base.OnCreate(bundle);
		SetContentView(Resource.Layout.main_activity);
		Cheeseknife.Inject(this);
		textView.Text = "This text view reference was injected!";
	}
}
```
Usage - Fragment
-------------------------
```csharp
public class ExampleFragment : Fragment {
	[InjectView(Resource.Id.list_view)]
	ListView listView;
	
	[InjectOnItemClick(Resource.Id.list_view)]
	void OnListViewItemClick(object sender, AdapterView.ItemClickEventArgs e) {
		// This code will run when a list item is clicked ...
	}

	public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
		var view = inflater.Inflate(Resource.Layout.list_sample_fragment, null);
		Cheeseknife.Inject(this, view);
		// Do your fragment initialisation here, all views will be available...
		return view;
	}

	public override void OnDestroyView() {
		base.OnDestroyView();
		Cheeseknife.Reset(this);
	}
}
```
Usage - List adapter with ViewHolder pattern
-----------------------------------------------------------
```csharp
public class ListSampleAdapter : BaseAdapter {
	public override View GetView(int position, View convertView, ViewGroup parent) {
		ViewHolder viewHolder;

		if(convertView == null) {
			convertView = LayoutInflater
				.From(MainApplication.Context)
				.Inflate(Resource.Layout.list_sample_list_item, parent, false);
			viewHolder = new ViewHolder(convertView);
			convertView.Tag = viewHolder;
		} else {
			viewHolder = (ViewHolder)convertView.Tag;
		}

		viewHolder.TitleView.Text = listData[position];
		
		return convertView;
	}

	class ViewHolder : Java.Lang.Object {
		[InjectView(Resource.Id.title_text_view)]
		public TextView TitleView { get; private set; }

		public ViewHolder(View view) {
			Cheeseknife.Inject(this, view);
		}
	}
}
```
Supported Cheeseknife events
------------------------------------------

Cheeseknife supports some of the most common Android view events:

__Click Event - applied to View objects__

```csharp
[InjectOnClick(Resource.Id.some_view)]
void SomeMethodName(object sender, EventArgs e) { ... }
```
__Touch Event - applied to View objects__

```csharp
[InjectOnTouch(Resource.Id.some_view)]
void SomeMethodName(object sender, View.TouchEventArgs e) { ... }
```
__Long Click Event - applied to View objects__

```csharp
[InjectOnLongClick(Resource.Id.some_view)]
void SomeMethodName(object sender, View.LongClickEventArgs e) { ... }
```
__Item Click Event - applied to AdapterView objects__

```csharp
[InjectOnItemClick(Resource.Id.some_list_view)]
void SomeMethodName(object sender, AdapterView.ItemClickEventArgs e) { ... }
```
__Item Long Click Event - applied to AdapterView objects__

```csharp
[InjectOnItemLongClick(Resource.Id.some_list_view)]
void SomeMethodName(object sender, AdapterView.ItemLongClickEventArgs e) { ... }
```
__Focus Change Event - applied to View objects__

```csharp
[InjectOnFocusChange(Resource.Id.some_view)]
void SomeMethodName(object sender, View.FocusChangeEventArgs e) { ... }
```
__Checked Change Event - applied to CompoundButton objects__

```csharp
[InjectOnCheckedChange(Resource.Id.some_compound_button_view)]
void SomeMethodName(object sender, CompoundButton.CheckedChangeEventArgs e) { ... }
```
__Text Changed Event - applied to TextView objects__

```csharp
[InjectOnTextChanged(Resource.Id.some_text_view)]
void SomeMethodName(object sender, Android.Text.TextChangedEventArgs e) { ... }
```
__Text Editor Action Event - applied to TextView objects__

```csharp
[InjectOnEditorAction(Resource.Id.some_text_view)]
void SomeMethodName(object sender, TextView.EditorActionEventArgs e) { ... }
```
Adding more Cheeseknife events
--------------------------------------------

If you would like Cheeseknife to support other Android view events you can edit `Cheeseknife.cs` if you are using the source file version of the library, and add your own injection attributes. There are three steps to include a new event, for this example we will register the `Scroll` event found on `ListView` objects.

Step 1 - Create a new annotation class
----------------------------------------------------

Each injection annotation is its own class. To make a new annotation, you just need to make a new class that has the same structure as the other Cheeseknife annotation classes. For our `Scroll` event, add the following class to `Cheeseknife.cs`:

```csharp
[AttributeUsage(AttributeTargets.Method)]
public class InjectOnScroll : BaseInjectionAttribute {
	public InjectOnScroll(int resourceId) : base(resourceId) { }
}
```
Step 2 - Registering the annotation with Cheeseknife
----------------------------------------------------------------------
The annotation and string name of the Xamarin exposed event needs to be registered in the main Cheeseknife class so it can be found via reflection during injection:

```csharp
static Dictionary<Type, string> GetInjectableEvents() {
	var types = new Dictionary<Type, string>();	
	...	
	types.Add(typeof(InjectOnScroll), "Scroll");

	return types;
}
```
Step 3 - Preventing the Xamarin linker from stripping the event
-----------------------------------------------------------------------------------
By default if you don't actually reference an event in your code, the linker will strip it out during a release build which will make your app implode and probably make kittens cry somewhere.

To prevent this, we need to make a dummy reference (that will never actually be used) to `preserve` the event we want to use.

```csharp
[Preserve]
static void InjectionEventPreserver() {
	...
	new ListView(null).Scroll += (s, e) => {};
}
```
All done! How to use your new injection annotation
-------------------------------------------------------------------
You can now use your new injection annotation in your Android app. For our example you could use the following code to inject the `Scroll` event onto a ListView. Note that you need to match the signature of your custom method to be the same as if you had added the event manually via the Xamarin APIs ie  `object sender, AbsListView.ScrollEventArgs e)`:

```csharp
public class ExampleActivity : Activity {
	[InjectOnScroll(Resource.Id.list_view)]
	void OnListViewScroll(object sender, AbsListView.ScrollEventArgs e) {
		// This code will run when the list view scrolls ...
	}

	protected override void OnCreate(Bundle bundle) {
		base.OnCreate(bundle);
		SetContentView(Resource.Layout.main_activity);
		Cheeseknife.Inject(this);
	}
}
```
