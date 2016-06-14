package md53495476648710d071d2a33b732732185;


public class Home
	extends md53495476648710d071d2a33b732732185.CustomActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Standard_Demo_Environment.Home, Standard Demo Environment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Home.class, __md_methods);
	}


	public Home () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Home.class)
			mono.android.TypeManager.Activate ("Standard_Demo_Environment.Home, Standard Demo Environment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
