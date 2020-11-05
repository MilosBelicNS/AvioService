Avio saobraca

-U projektu smo napravili 3 klase koje opisuju tri objekta.
-U bazi podataka smo naveli sve atribute objekata i napravili tabele.

-DAO folder: u ovom folderu su DAO klase u kojima su metode za dobavljanje objekata iz baze podataka, tacnije metode u kojima smo pravili upite za bazu kao sto su:GetALL, GetById, GetByName, Create, i Delete.

-UI folder: u ovom folderu su smestene 3 ui klase za svaki objekat, u kojima su metode IspisiMeni, Meni(u pitanju je meni za objekat date klase), i metode koje unose, brisu, pretrazuju objekte. Ove metode u sebi imaju poziv metoda iz DAO klasa koje u stvari dobavljaju objekte iz baze.

-AplikacijaUI je klasa u kojoj ispisujemo meni same aplikacije, i njegovo ispisivanje.

-IOPomocnaKlasa je klasa u kojoj smo naveli metode koje proveravaju input sa konzole npr ProveraDaliJeBroj, OcitajTekst, OcitajBroj,OcitajChar, OcitajRealanBroj, OcitajOdlukuOPotvrdi.

-Program klasa je klasa u kojoj pozivamo klasu AplikacijaUI, I U NJOJ SMO NAVELI CONNECTIONSTRING koji nas veze sa bazom podataka.
END