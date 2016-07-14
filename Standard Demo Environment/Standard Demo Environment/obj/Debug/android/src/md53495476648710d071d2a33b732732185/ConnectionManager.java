package md53495476648710d071d2a33b732732185;


public class ConnectionManager
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Standard_Demo_Environment.ConnectionManager, Standard Demo Environment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ConnectionManager.class, __md_methods);
	}


	public ConnectionManager () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ConnectionManager.class)
			mono.android.TypeManager.Activate ("Standard_Demo_Environment.ConnectionManager, Standard Demo Environment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
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
