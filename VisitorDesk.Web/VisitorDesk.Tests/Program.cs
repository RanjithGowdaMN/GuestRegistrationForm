static void Equal(string expected,string actual,string description) { if(expected!=actual)throw new Exception(description+": expected "+expected+", received "+actual); }
var qid=IdentityTextProcessor.Extract("State Of Qatar\nID No: 12345678901\nName: Test Sample Visitor\nNationality QATARI\nD.0.B: 1/2/1990\nExpiry: 2030-01-01");
Equal("12345678901",qid["idNumber"],"QID");Equal("Test Sample Visitor",qid["name"],"Mixed-case name");Equal("1990-02-01",qid["dob"],"DOB");Equal("2030-01-01",qid["expiry"],"ISO expiry");
var separated=IdentityTextProcessor.Extract("Name:\nTEST PERSON\nNationality:\nQATARI\nPassport No:\nAB1234567");
Equal("TEST PERSON",separated["name"],"Separate-line name");Equal("AB1234567",separated["idNumber"],"Labelled passport");
Equal("JOHN DOE",IdentityTextProcessor.Extract("Name:JOHN DOE")["name"],"Compact label");
var invalid=IdentityTextProcessor.Extract("Company Name: NOT A PERSON\nD.O.B: 31/02/1990\nExpiry: 99/99/2030\nID No: 1234");
if(invalid.Count!=0)throw new Exception("Invalid labels/dates must not produce identity fields");
const string mrz="P<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<<<<<<<<<\n\nL898902C36UTO7408122F1204159ZE184226B<<<<<10";
var passport=IdentityTextProcessor.Extract(mrz);
Equal("L898902C3",passport["idNumber"],"MRZ document number");Equal("ANNA MARIA ERIKSSON",passport["name"],"MRZ name");Equal("1974-08-12",passport["dob"],"MRZ DOB");
if(IdentityTextProcessor.Extract(mrz.Replace("L898902C36","L898902C35")).Count!=0)throw new Exception("Failed MRZ checksum must be rejected");
if(IdentityTextProcessor.Extract("").Count!=0)throw new Exception("Empty extraction leaked previous identity");
Console.WriteLine("Passed: Qatar labels/dates, split labels, passport labels, invalid input, valid MRZ, invalid checksum, request isolation.");
