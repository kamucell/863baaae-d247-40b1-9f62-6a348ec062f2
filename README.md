
Hi,

Sorry for the delay.

>  
>  In two hours, I was only able to implement the account functionality and spent some time working on the audit and transaction features, but I couldn't complete them.  I have added the zip files containing what I done in two hours.  file name : 863baaae-d247-40b1-9f62-6a348ec062f2-main_inTowHours.zip
>  
For audit and transaction functionality, I usually prefer  AOP (Aspect-Oriented Programming) and DI approaches. I often use libraries like Castle or Autofac (an extension of Castle) for this purpose.


 

>  
>  All functionalities is implemented and added in this repository. first  version :863baaae-d247-40b1-9f62-6a348ec062f2-main_inTowHours.zip
>  



New Version 

- Corrected the error message text
- Created a custom exception for critical business situations and use UnauthorizedAccountOperationException instead of GenericException.
- Completed the implementation of Lockdown.
- Finished the implementation of Audit.
