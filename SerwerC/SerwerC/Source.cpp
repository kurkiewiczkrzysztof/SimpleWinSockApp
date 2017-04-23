#pragma warning(disable:4244)
#pragma warning(disable:4996 4005)
#define _CRT_SECURE_NO_WARNINGS
#define _USE_MATH_DEFINES
#ifdef UNICODE
#undef UNICODE
#define _MBCS
#endif

#include <WinSock2.h>
#pragma comment(lib,"ws2_32.lib")

#include <mysql.h>
#include <string>
#include <vector>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <fstream>
#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <ctime>
#include <time.h>

using namespace std;


struct connection_details
{
	char *server;
	char *user;
	char *password;
	char *database;
};

MYSQL* mysql_connection_setup(struct connection_details mysql_details)
{
	MYSQL *connection = mysql_init(NULL);

	if (!mysql_real_connect(connection, mysql_details.server, mysql_details.user, mysql_details.password, mysql_details.database, 0, NULL, 0)) {
		printf("Conection error : %s\n", mysql_error(connection));
		exit(1);
	}
	return connection;
}

MYSQL_RES* mysql_perform_query(MYSQL *connection, char *sql_query)
{
	if (mysql_query(connection, sql_query))
	{
		printf("MySQL query error : %s\n", mysql_error(connection));
		exit(1);
	}

	return mysql_use_result(connection);
}



char* asctime(const struct tm *timeptr)
{
	static const char wday_name[][4] = {
		"Ni", "Pon", "Wt", "Sr", "Czw", "Pi", "So"
	};
	static const char mon_name[][4] = {
		"Sty", "Lu", "Mar", "Kwi", "Maj", "Cze",
		"Lip", "Sie", "Wrz", "Paz", "Lis", "Gru"
	};

	static char result[27];
	sprintf(result, "%.3s-%d::%.2d",
		mon_name[timeptr->tm_mon],
		timeptr->tm_mday,
		1900 + timeptr->tm_year);

	return result;
}


DWORD WINAPI ObslugaKlienta(LPVOID wejDane)
{
	MYSQL *conn;
	MYSQL_RES *res;
	MYSQL_ROW row;


	struct connection_details mysqlD;
	mysqlD.server = "mysql3.gear.host";
	mysqlD.user = "sklepc1";	
	mysqlD.password = "ZAQ!2wsx"; 
	mysqlD.database = "sklepc1";	

	SOCKET polaczenie = *(SOCKET*)wejDane;

	conn = mysql_connection_setup(mysqlD);
	while (true) {
		res = mysql_perform_query(conn, "SELECT * FROM Kategoria");
		printf("Kategorie, wpisz odpowiednia cyfre:\n");

		char st[2500] = "";
		char st3[2500] = " ";
		char st6[2500] = "\n";
		char suma3[2500] = "";
		int i = 0;
		while ((row = mysql_fetch_row(res)) != NULL) {
			strncpy(st, row[0], 2500);
			strcat(suma3, st);
			strcat(suma3, st3);
			strncpy(st, row[1], 2500);
			strcat(suma3, st);
			strcat(suma3, st3);
		}
		printf("Wysylam menu\n");

		const size_t nBufor = 4096;

		while (true)
		{

			char bufor[nBufor] = { '\0' };
			int zwrot, wszystko, biezacy, zwrot2;
			int odbierzOdpMenu, odbierzNumerSprzetu, odbierzFlage, odbierzdruga, odbierztrzecia;
			char odpowiedz[1] = { '\0' };
			char odpowiedz2[1] = { '\0' };
			char odpowiedz3[1] = { '\0' };
			char odpowiedz4[1] = { '\0' };

			strcat(suma3, bufor);
			wszystko = strlen(suma3);
			biezacy = 0;

			zwrot = send(polaczenie, &suma3[biezacy], wszystko, 0);
			if (zwrot == 0) break;
			else if (zwrot <= SOCKET_ERROR) abort;
			wszystko -= zwrot;
			biezacy += zwrot;

			odbierzOdpMenu = recv(polaczenie, odpowiedz, 1, 0);

			int vOut = atoi(odpowiedz);
			do {

				if (odbierzOdpMenu <= -1)break;
				char suma5[2500] = "";
				char st5[2500] = " ";
				char suma4[2500] = "";
				if (vOut == 0) {
					res = mysql_perform_query(conn, "SELECT * FROM Kategoria");
					char st[2500] = "";
					char st3[2500] = " ";
					char st6[2500] = "\n";
					char suma3[2500] = "";
					int i = 0;
					while ((row = mysql_fetch_row(res)) != NULL) {
						strncpy(st, row[0], 2500);
						strcat(suma4, st);
						strcat(suma4, st3);
						strncpy(st, row[1], 2500);
						strcat(suma4, st);
						strcat(suma4, st3);
						strcat(suma4, bufor);
					}
					wszystko = strlen(suma4);
					biezacy = 0;
					char st4[2500] = "5 Historia";
					strcat(suma4, st4);
					printf("\nWysylam menu");
					zwrot2 = send(polaczenie, &suma4[biezacy], wszystko, 0);
					odbierzNumerSprzetu = recv(polaczenie, odpowiedz2, 1, 0);
					if (odbierzNumerSprzetu <= -1)break;	
					vOut = atoi(odpowiedz2);
				}
				else if (vOut == 5)
				{
					res = mysql_perform_query(conn, "SELECT * FROM sprzet where historia=1");
					while ((row = mysql_fetch_row(res)) != NULL) {
						strncpy(st5, row[0], 2500);
						strcat(suma4, st5);
						strcat(suma4, st3);
						strncpy(st5, row[1], 2500);
						strcat(suma4, st5);
						strcat(suma4, st3);
						strncpy(st5, row[2], 2500);
						strcat(suma4, st5);
						strcat(suma4, st3);
						strncpy(st5, row[5], 2500);
						strcat(suma4, st5);
						strcat(suma4, st3);
					}
					strcat(suma4, bufor);
					printf("\nWysylam historie");
					wszystko = strlen(suma4);
					biezacy = 0;
					zwrot2 = send(polaczenie, &suma4[biezacy], wszystko, 0);
					odbierzNumerSprzetu = recv(polaczenie, odpowiedz2, 1, 0);
					if (odbierzNumerSprzetu <= -1)break;
					vOut = atoi(odpowiedz2);
				}
				else if (vOut == 8)
				{
					char str[10];
					send(polaczenie, NULL, 0, 0);
					odbierzFlage = recv(polaczenie, odpowiedz3, 2, 0);
					if (odbierzFlage <= -1)break;
					int vOut3 = atoi(odpowiedz3);
					itoa(vOut3, str, 10);
					char str2[10];
					char statemant2[250] = "Update sprzet set Historia=1 where idSprzetu=";
					strcat(statemant2, str);
					time_t t = time(NULL);
					const struct tm *tm = localtime(&t);

					char buffer[80];
					char *data = asctime(tm);
					char statemant3[250] = "Update sprzet set Data=\"";
					strcat(statemant3, data);
					char reststatement3[250] = "\" Where idSprzetu=";
					strcat(statemant3, reststatement3);
					strcat(statemant3, str);
					res = mysql_perform_query(conn, statemant2);
					res = mysql_perform_query(conn, statemant3);
					printf("\nKlient dokonal zakupu");
					send(polaczenie, NULL, 0, 0);
					odbierztrzecia = recv(polaczenie, odpowiedz4, 1, 0);
					if (odbierztrzecia <= -1)break;
					vOut = 0;
				}
				else {

					if (vOut == 1)
						res = mysql_perform_query(conn, "SELECT * FROM sprzet where Kategoria_idKategorii=1 AND historia=0 AND ilosc>0");
					if (vOut == 2)
						res = mysql_perform_query(conn, "SELECT * FROM sprzet where Kategoria_idKategorii=2 AND historia=0 AND ilosc>0");
					if (vOut == 3)
						res = mysql_perform_query(conn, "SELECT * FROM sprzet where Kategoria_idKategorii=3 AND historia=0 AND ilosc>0");
					if (vOut == 4)
						res = mysql_perform_query(conn, "SELECT * FROM sprzet where Kategoria_idKategorii=4 AND historia=0 AND ilosc>0");

					if (vOut == 1)printf("\nWysylam wybrana kategorie: Monitory");
					if (vOut == 2)printf("\nWysylam wybrana kategorie: Tablety");
					if (vOut == 3)printf("\nWysylam wybrana kategorie: Laptopy");
					if (vOut == 4)printf("\nWysylam wybrana kategorie: Klawiatury");

					while ((row = mysql_fetch_row(res)) != NULL) {

						strncpy(st5, row[0], 2500);
						strcat(suma4, st5);
						strcat(suma4, st3);
						strncpy(st5, row[1], 2500);
						strcat(suma4, st5);
						strcat(suma4, st3);
						strncpy(st5, row[2], 2500);
						strcat(suma4, st5);
						strcat(suma4, st3);
					}
					strcat(suma4, bufor);
					wszystko = strlen(suma4);
					biezacy = 0;
					zwrot2 = send(polaczenie, &suma4[biezacy], wszystko, 0);
					odbierzNumerSprzetu = recv(polaczenie, odpowiedz2, 1, 0);
					if (odbierzNumerSprzetu <= -1)break;
					vOut = atoi(odpowiedz2);
				}
			} while (zwrot > -1);
		}
	}

}


void main()
{
	printf(">>Poczatek programu <<\n\n");
	vector<HANDLE> watki;


	const u_short iPort = 5000;
	const size_t nTablica = 1024;

	WSADATA info;
	SOCKET nasluch, polaczenie;
	sockaddr_in lokalny, zdalny;
	int rozmiar;

	if (WSAStartup(MAKEWORD(2, 2), &info) != 00) abort();
	nasluch = socket(AF_INET, SOCK_STREAM, IPPROTO_IP);
	if (nasluch == SOCKET_ERROR) abort();

	lokalny.sin_family = AF_INET;
	lokalny.sin_addr.s_addr = INADDR_ANY;
	lokalny.sin_port = htons(iPort);
	if (bind(nasluch, (sockaddr *)&lokalny, sizeof lokalny) != 0)abort;


	do {
		printf("\nOczekiwanie na polaczenie... \n");
		listen(nasluch, SOMAXCONN);

		rozmiar = sizeof zdalny;
		polaczenie = accept(nasluch, (sockaddr *)&zdalny, &rozmiar);
		if (polaczenie == INVALID_SOCKET) abort();
		printf("\nZaakceptowane polaczenie: %s, port: %d\n", inet_ntoa(zdalny.sin_addr), ntohs(zdalny.sin_port));

		HANDLE watek;

		DWORD ident;

		watek = CreateThread(NULL,0, ObslugaKlienta, &polaczenie,CREATE_SUSPENDED, &ident );

		watki.push_back(watek);
		ResumeThread(watek);
		Sleep(10);
	} while (true);

	printf("\nprogram czeka na zakonczenie procesow i watkow...\n");

	HANDLE watek;
	for (vector<HANDLE>::iterator watek = watki.begin(); watek<watki.end(); watek++) {
		WaitForSingleObject(*watek, INFINITE); 
		CloseHandle(*watek);
	}
	watki.clear();
}
