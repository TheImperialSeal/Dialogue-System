using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;

public class DialogueVariables
{

    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; } //The string is the variable name, the ink.runtime.object is the value of the variable

    public DialogueVariables(string globalsFilePath)
    {
        //commpile the globals file
        //annoyingly, include files do not get compiled by default which means we have to do it like this.
        //It's worth noting that this specific solution will not work when trying to build the project
        //There is a workaround that I will need to implement at a later date


        string inkFileContents = File.ReadAllText(globalsFilePath);
        Ink.Compiler compiler = new Ink.Compiler(inkFileContents);
        Story globalVariablesStory = compiler.Compile();

        //initialise the dictionary

        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach(string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Initialised global dialogue variable: " + name + " = " + value);
        }
    } 

    //start and stop listening for changes when the Player enters conversation. Avoids running the listeners in the background unecessarily
    public void StartListening(Story story)
    {
        //VariablesToStory has to be assigned before the observer, otherwise errors will occur
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    //This method is called when a variable changes to update the dictionary
    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        variables.Remove(name);
        variables.Add(name, value);
    }

    private void VariablesToStory(Story story)
    {
        foreach(KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
