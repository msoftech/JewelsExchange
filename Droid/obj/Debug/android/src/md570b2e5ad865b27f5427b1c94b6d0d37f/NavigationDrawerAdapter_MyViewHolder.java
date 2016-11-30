package md570b2e5ad865b27f5427b1c94b6d0d37f;


public class NavigationDrawerAdapter_MyViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("JewelsExchange.Droid.NavigationDrawerAdapter+MyViewHolder, JewelsExchange.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", NavigationDrawerAdapter_MyViewHolder.class, __md_methods);
	}


	public NavigationDrawerAdapter_MyViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == NavigationDrawerAdapter_MyViewHolder.class)
			mono.android.TypeManager.Activate ("JewelsExchange.Droid.NavigationDrawerAdapter+MyViewHolder, JewelsExchange.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
