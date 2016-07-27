package md53495476648710d071d2a33b732732185;


public class PushNotificationService
	extends md5ac94a677a11273e2eafc60527165404e.KinveyGCMService
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Standard_Demo_Environment.PushNotificationService, Standard Demo Environment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PushNotificationService.class, __md_methods);
	}


	public PushNotificationService (java.lang.String p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == PushNotificationService.class)
			mono.android.TypeManager.Activate ("Standard_Demo_Environment.PushNotificationService, Standard Demo Environment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}


	public PushNotificationService () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PushNotificationService.class)
			mono.android.TypeManager.Activate ("Standard_Demo_Environment.PushNotificationService, Standard Demo Environment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
