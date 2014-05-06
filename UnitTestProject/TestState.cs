using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HeadFirstDesignPattern.State;

namespace UnitTestProject
{
    [TestClass]
    public class TestState
    {
        GumballMachine gumball_machine;
        GumballMachineStart gumball_machine_start;

        [TestInitialize]
        public void Setup()
        {
            gumball_machine = new GumballMachine(5);
            gumball_machine_start = new GumballMachineStart(5);
        }

        [TestCleanup]
        public void TearDown()
        {

        }

        [TestMethod]
        public void Test_GumballMachineStartTestDrive()
        {
            System.Diagnostics.Debug.WriteLine(gumball_machine_start.MachineState());

            gumball_machine_start.InsertQuarter();
            gumball_machine_start.TurnCrank();

            System.Diagnostics.Debug.WriteLine(gumball_machine_start.MachineState());

            gumball_machine_start.InsertQuarter();
            gumball_machine_start.EjectQuarter();
            gumball_machine_start.TurnCrank();

            System.Diagnostics.Debug.WriteLine(gumball_machine_start.MachineState());

            gumball_machine_start.InsertQuarter();
            gumball_machine_start.TurnCrank();
            gumball_machine_start.InsertQuarter();
            gumball_machine_start.TurnCrank();
            gumball_machine_start.EjectQuarter();

            System.Diagnostics.Debug.WriteLine(gumball_machine_start.MachineState());

            gumball_machine_start.InsertQuarter();
            gumball_machine_start.InsertQuarter();
            gumball_machine_start.TurnCrank();
            gumball_machine_start.InsertQuarter();
            gumball_machine_start.TurnCrank();
            gumball_machine_start.InsertQuarter();
            gumball_machine_start.TurnCrank();

            System.Diagnostics.Debug.WriteLine(gumball_machine_start.MachineState());
        }

        [TestMethod]
        public void Test_GumballMachineTestDrive()
        {
            System.Diagnostics.Debug.WriteLine(gumball_machine.MachineStateHeader());

            gumball_machine.InsertQuarter();
            gumball_machine.TurnCrank();

            System.Diagnostics.Debug.WriteLine(gumball_machine.MachineStateHeader());

            gumball_machine.InsertQuarter();
            gumball_machine.EjectQuarter();
            gumball_machine.TurnCrank();

            System.Diagnostics.Debug.WriteLine(gumball_machine.MachineStateHeader());

            gumball_machine.InsertQuarter();
            gumball_machine.TurnCrank();
            gumball_machine.InsertQuarter();
            gumball_machine.TurnCrank();
            gumball_machine.EjectQuarter();

            System.Diagnostics.Debug.WriteLine(gumball_machine.MachineStateHeader());

            gumball_machine.InsertQuarter();
            gumball_machine.InsertQuarter();
            gumball_machine.TurnCrank();
            gumball_machine.InsertQuarter();
            gumball_machine.TurnCrank();
            gumball_machine.InsertQuarter();
            gumball_machine.TurnCrank();

            System.Diagnostics.Debug.WriteLine(gumball_machine.MachineStateHeader());
        }
    }
}
