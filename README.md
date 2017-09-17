CslaGenFork
===

![](https://raw.github.com/CslaGenFork/CslaGenFork/master/Support/Logos/Project-Logo-final.gif)

O/RM code generator for CSLA.NET 4.3/4.5/4.6 generating Stored Procedures, Business Layer and Data Access Layer code for Windows Forms, ASP.NET, WPF and Silverlight.
There is a complete set of C# templates. Currently there are VB templates, but only for non DAL architecture. You are welcome to contribute with VB templates for DAL DataReader and DAL using DTO.

2017 Mar 01 - Version 4.6.0 released ![](https://raw.github.com/CslaGenFork/CslaGenFork/master/Home/Home_star.png)
---

This release will bring a lot of new features and some usability improvements.

1. Besides SQL Server, code generation can target other database engines like:
- Oracle Database
- PostgreSQL
- Firebird
- MySQL
- SQLite

2. Numerous fixes to VB code generation

3. New kinds of CslaObject
- generate abstract base classes for inheritance purposes
- generate custom criteria classes inheriting from BusinessBase that are easier to tailor to your needs
- place holder - this kind of object doesn't generate code, but it can be used to group objects (in light blue)

![](https://raw.github.com/CslaGenFork/CslaGenFork/master/Support/Home/Home_CGF-PlaceHolder.png)

4. Improved property handling
- Support for custom types (enums etc)
- Support for database unbound properties
- Support for properties persisted to the database as null (read and WRITE)

5. Improved inheritance support
- fix templates and visual details
- allow inheritance from base types defined on assembly and on the project
- improve filters on inheritance objects lists so they only show the types that make sense

6. Handle the Saved static event raised by EditableRoot with Weak Event (the generated code was causing memory leaks)

7. Improved database type handling (doesn't crash on geography, etc)

UI improvements

- Improve Enum's display - for instance, show Editable Child Collection instead of EditableChildCollection or show C# instead of CSharp
- Improve UI field hiding (show only UI fields that make sense)
- Improve type filtering (show only objects/properties that make sense).
- Introduce "Don't ask again" MessageBoxEx control and apply it where it fits.

Breaking changes
---

The incomplete feature Generate BypassPropertyChecks was dropped.

CGF was full of legacy code and templates. Those parts were never changed but it was unclear whether they were actually useful. To make new developments easier, legacy support was dropped.
- Support code and templates for pre CSLA .NET 4.0 projects was removed. CGF will help you convert your project file to a supported version of CSLA .NET.
- Support for active objects and for the plugin system was removed, as these options were available only for legacy projects.
For those of you that continue to generate code for legacy CSLA versions, CslaGenFork 4.5.4 is and will be available on [old CodePlex site](https://cslagenfork.codeplex.com/releases/view/616261).

Other projects
---
2017 Sep 04 - Rules sample moved to CslaContrib
- The rules in CslaGenFork library were added to CslaContrib library.

2013 Jan 27 - DeepLoad sample v3.0.1 - download here
- The DeepLoad sample project tests the loading part of a 6 levels deep data structure, from Continents to City Roads. This project illustrates how to use CslaGenFork to generate deep objects.

Get started
---
Is code generation a good idea?

If you were told generated code is bug ridden or rigid or code gen tools are just toys, then have a second opinion.

Why would I use CslaGenFork?
---
If you had some bad experiences with CslaGen or other code gen tools, then you don't need a feature list but an argument list.

How do I use CslaGenFork?
---
No, you are not sent out to the wild on your own. We try to help all the way. Or at least, some of the way...
- How do I start using it?
- How do I organize myself?
- Do I need some tools?
- Where do I fetch the free CodeSmith engine?
- Is there a suggested workflow for codegen?

More documents
---
2011 Jul 02 - Cheat Sheet contents includes:

How to create objects and collections by point and click
How to create child objects and child collections by point and click
What are those dreaded Parent Properties
How to use DataAnnotations validation rules

Is there a sample?
---
There is a work in progress started 2011 Feb 15. Look under the Documentation tab or go straight to the Invoicing sample.

Is there a FAQ?
---
Of course there is! It's brand new and it's a moving target meaning I'm adding questions every now and then.
Read it here (2010-12-08 update).

Useful links:
---
Rocky Lhotka's CSLA.NET site
CSLA.NET forum
Manual (the closest thing you can get) CSLAGenWiki
For codegen samples, search "The Code Project" for CslaGen

About the license...
---
CslaGenFork is GPL 2 as CodePlex doesn't allow GPL 3. The GPL license is an inheritance from the original CslaGen code generator. Of course you can use the generated code as you like: sell, borrow, lend or even give away.

Acknowledgements
---
CslaGen couldn't exist without the free CodeSmith DLL. Great care was taken in not breaching the CodeSmith license agreement neither by CslaGenFork nor by anyone using it, Thank you CodeSmith.

![](https://raw.github.com/CslaGenFork/CslaGenFork/master/Support/Home/Home_ReSharper.png)
