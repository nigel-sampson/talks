Cheeseknife
==========

Inspired by the Java `Butter Knife` library for Android, Cheeseknife is a view injection library for Xamarin.Android to ease the pain of manually resolving each and every one of your Android views and events in your view lifecycles. Injection occurs at runtime rather than compile time and uses C# attributes to mark Android view member fields for injection.

Consider this typical code to wire up your Android views and events:

```csharp
public class ExampleActivity : Activity {
	TextView textView1;
	TextView textView2;
	TextView textView3;
	Button button;
	ListView listView;

	protected override void OnCreate(Bundle bundle) {
		base.OnCreate(bundle);
		SetContentView(Resource.Layout.main_activity);
		
		textView1 = FindViewById<TextView>(Resource.Id.text_view1);
		textView2 = FindViewById<TextView>(Resource.Id.text_view2);
		textView3 = FindViewById<TextView>(Resource.Id.text_view3);
		button = FindViewById<Button>(Resource.Id.button);
		listView = FindViewById<ListView>(Resource.Id.list_view);
		
		button.Click += (object sender, EventArgs e) {
			...		}
		listView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) {
			...		}		
	}
}
```

With Cheeseknife, you can do this:

```csharp
public class ExampleActivity : Activity {
	[InjectView(Resource.Id.text_view1)] TextView textView1;
	[InjectView(Resource.Id.text_view2)] TextView textView2;
	[InjectView(Resource.Id.text_view3)] TextView textView3;
	[InjectView(Resource.Id.button)] Button button;
	[InjectView(Resource.Id.list_view)] ListView listView;
	
	[InjectOnClick(Resource.Id.button)]
	void OnClickButton(object sender, EventArgs e) {
		// This code will run when the button is clicked ...
	}
	[InjectOnItemClick(Resource.Id.list_view)]
	void OnClickListView(object sender, AdapterView.ItemClickEventArgs e) {
		// This code will run when at item in listView is clicked ...
	}

	protected override void OnCreate(Bundle bundle) {
		base.OnCreate(bundle);
		SetContentView(Resource.Layout.main_activity);
		Cheeseknife.Inject(this);
		// All done! All views and events are wired up!
	}
}
```