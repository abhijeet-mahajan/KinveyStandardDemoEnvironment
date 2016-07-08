package md53495476648710d071d2a33b732732185;


public class Authenticate
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Standard_Demo_Environment.Authenticate, Standard Demo Environment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Authenticate.class, __md_methods);
	}


	public Authenticate () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Authenticate.class)
			mono.android.TypeManager.Activate ("Standard_Demo_Environment.Authenticate, Standard Demo Environment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
