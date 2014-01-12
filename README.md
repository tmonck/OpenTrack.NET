OpenTrack.NET
===========

This library works as an interface between the OpenTrack API from DealerTrack's DMS and a utilizing system. 

Please utilize the ISSUES tracker at https://github.com/asrpro/OpenTrack.NET for any questions or bug reports.

All rights to OpenTrack and DealerTrack remain property of DealerTrack. Please see [http://www.dealertrack.com/dms/](http://www.dealertrack.com/dms/) for more information.

## Contact Info

If you find this library useful or have any questions, send an email to MattGWagner@Gmail.com or developers@asrpro.com.


## API URLs
OpenTrack API no longer requires `ServerName` field to be sent with the requests.  To send requests to different environments, simply change the service URL.

### Staging URLs
- https://otstaging.arkona.com/OpenTrack/WebService.asmx
- https://otstaging.arkona.com/opentrack/ServiceAPI.asmx
- https://otstaging.arkona.com/OpenTrack/PartsAPI.asmx

### Pre-Prod URLs
- https://otcert.arkona.com/OpenTrack/WebService.asmx
- https://otcert.arkona.com/OpenTrack/ServiceAPI.asmx
- https://otcert.arkona.com/OpenTrack/PartsAPI.asmx

### Production URLs
- https://ot.dms.dealertrack.com/WebService.asmx
- https://ot.dms.dealertrack.com/ServiceAPI.asmx
- https://ot.dms.dealertrack.com/PartsAPI.asmx
