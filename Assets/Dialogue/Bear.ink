INCLUDE Globals.ink
VAR bear_passed = true
->BearStart

{ BearPassed: == 0: -> BearStart | -> BearEnd }

=== BearStart ===

I'm not letting you past

* [Come on Ursa, let me past you stupid fat bear]
    ->BearFailed

* [But this is really important, the fate of the village is at stake]
    ->BearPassed

* [Well it was good while it lasted, I'm going home]
    ->BearFailed

* [I know you're just doing your job but I need your help to save everyone]
    ->BearPassed

=== BearPassed ===
~ bear_passed = true
-> BearEnd



=== BearFailed ===
~ bear_passed = false
-> BearEnd


=== BearEnd ===
{ 
-bear_passed == true:
    bear was passed
-else:
    bear not passed
}

~bearStatus = bear_passed

->DONE