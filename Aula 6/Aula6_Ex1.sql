use pubs;

-- Aula 6 - Ex.1

--a) Todos os tuplos da tabela autores (authors);
SELECT * FROM authors;

--b) O primeiro nome, o último nome e o telefone dos autores;
SELECT au_fname,au_lname,phone FROM authors;

--c) Consulta definida em b) mas ordenada pelo primeiro nome (ascendente) e depois o último nome (ascendente);
SELECT au_fname, au_lname, phone FROM authors
ORDER BY au_fname, au_lname;

--d) Consulta definida em c) mas renomeando os atributos para (first_name, last_name, telephone);
select au_fname as first_name, au_lname as last_name, phone as telephone
from authors
ORDER BY first_name, last_name;

--e) Consulta definida em d) mas só os autores da Califórnia (CA) cujo último nome é diferente de ‘Ringer’;
SELECT au_fname as first_name, au_lname as last_name, phone as telephone
FROM authors
WHERE state='CA' AND au_lname!='Ringer'
ORDER BY first_name, last_name;

--f) Todas as editoras (publishers) que tenham ‘Bo’ em qualquer parte do nome;
SELECT pub_name as Nome FROM publishers
WHERE pub_name like '%Bo%';

--g) Nome das editoras que têm pelo menos uma publicação do tipo ‘Business’;
SELECT pub_name as Nome FROM publishers 
JOIN titles ON publishers.pub_id=titles.pub_id
WHERE titles.[type]='Business'
GROUP BY pub_name;

--h) Número total de vendas de cada editora;
SELECT publishers.pub_id, publishers.pub_name as Nome, sum(titles.ytd_sales) as total_sales
FROM titles JOIN publishers on titles.pub_id=publishers.pub_id
GROUP BY publishers.pub_id, publishers.pub_name;

--i) Número total de vendas de cada editora agrupado por título;
SELECT publishers.pub_id, publishers.pub_name as Nome, titles.title, sum(sales.qty) as total_sales
FROM publishers JOIN titles ON publishers.pub_id=titles.pub_id JOIN sales ON titles.title_id=sales.title_id
GROUP BY publishers.pub_id, titles.title, publishers.pub_name
ORDER BY publishers.pub_name;

--j) Nome dos títulos vendidos pela loja ‘Bookbeat’;
SELECT titles.title as Title											 --, stores.stor_name as Store_Name
FROM titles JOIN sales ON titles.title_id = sales.title_id
	JOIN stores ON sales.stor_id = stores.stor_id
WHERE stores.stor_name = 'Bookbeat';

--k) Nome de autores que tenham publicações de tipos diferentes;
SELECT authors.au_fname as Frist_Name, authors.au_lname as Last_Name
FROM titleauthor JOIN titles ON titleauthor.title_id=titles.title_id JOIN authors ON titleauthor.au_id=authors.au_id
GROUP BY authors.au_fname, authors.au_lname
HAVING count(titles.[type])>1;

--l) Para os títulos, obter o preço médio e o número total de vendas agrupado por tipo (type) e editora (pub_id);
SELECT titles.title, titles.[type], avg(titles.price) as avg_price, sum(sales.qty) as total_sales, publishers.pub_id
FROM titles JOIN publishers ON titles.pub_id=publishers.pub_id JOIN sales ON titles.title_id = sales.title_id
GROUP BY titles.[type], publishers.pub_id, titles.title;

--m) Obter o(s) tipo(s) de título(s) para o(s) qual(is) o máximo de dinheiro “à cabeça” (advance) é uma vez e meia superior à média do grupo (tipo); 
SELECT titles.[type], titles.advance, average_advance
FROM titles JOIN (SELECT titles.[type], avg(titles.advance) as average_advance FROM titles
					GROUP BY [type]) as temp
ON titles.[type]=temp.[type]
WHERE titles.advance > temp.average_advance * 1.5;

--n) Obter, para cada título, nome dos autores e valor arrecadado por estes com a sua venda;
SELECT titles.title, authors.au_fname, authors.au_lname, price*royalty/100*royaltyper/100 as Arrecadado
FROM titles JOIN titleauthor ON titles.title_id = titleauthor.title_id
			JOIN authors ON titleauthor.au_id = authors.au_id
			JOIN sales ON titles.title_id = sales.title_id
GROUP BY titles.title, authors.au_fname, authors.au_lname, price*royalty/100*royaltyper/100;

--o) Obter uma lista que incluía o número de vendas de um título (ytd_sales), o seu nome, a faturação total, o valor da faturação relativa aos autores e o valor da faturação relativa à editora;
SELECT titles.title, titles.ytd_sales, titles.price*titles.ytd_sales as facturacao, royalty*0.01*price*ytd_sales as auth_revenue, price*ytd_sales-royalty*0.01*price*ytd_sales as publisher_revenue
FROM titles
ORDER BY titles.title;

-- *0.01 para converter para %

--p) Obter uma lista que incluía o número de vendas de um título (ytd_sales), o seu nome, o nome de cada autor, o valor da faturação de cada autor e o valor da faturação relativa à editora;
SELECT titles.title, titles.ytd_sales, authors.au_fname as First_Name, authors.au_lname as Last_Name, royalty*0.01*price*ytd_sales*royaltyper as auth_revenue, price*ytd_sales-royalty*0.01*price*ytd_sales as publisher_revenue
FROM titles JOIN titleauthor ON titles.title_id=titleauthor.title_id
	JOIN authors ON titleauthor.au_id=authors.au_id
ORDER BY titles.title;



--q) Lista de lojas que venderam pelo menos um exemplar de todos os livros;
SELECT stores.stor_id,stores.stor_name as Stor_Name, count(titles.title_id) as N_titles
FROM stores JOIN sales ON stores.stor_id=sales.stor_id JOIN titles ON sales.title_id=titles.title_id
GROUP BY stores.stor_id, stores.stor_name
HAVING count(titles.title_id)=(SELECT count(*) FROM titles);

--r) Lista de lojas que venderam mais livros do que a média de todas as lojas.
SELECT stores.stor_id, sum(sales.qty) as Sales_qty
FROM stores JOIN sales ON stores.stor_id=sales.stor_id
GROUP BY stores.stor_id
HAVING sum(sales.qty)> (
	SELECT avg(sales.qty) as avg_store_sales
		FROM stores JOIN sales ON stores.stor_id=sales.stor_id);

--s) Nome dos títulos que nunca foram vendidos na loja “Bookbeat”;	
SELECT titles.title_id, titles.title as Title
From titles
WHERE titles.title not in (
	SELECT sales.title_id
	FROM stores JOIN sales ON stores.stor_id=sales.stor_id
	WHERE stores.stor_name = 'Bookbeat'
	);
SELECT  titles.title_id, titles.title as Title
From titles
WHERE titles.title NOT IN (	SELECT sales.title_id
							FROM stores JOIN sales ON stores.stor_id=sales.stor_id
							WHERE stores.stor_name = 'Bookbeat'
						   );

--t) Para cada editora, a lista de todas as lojas que nunca venderam títulos dessa editora;
SELECT pub_name, stor_name
FROM publishers,stores
GROUP BY pub_name, stor_name
EXCEPT
(SELECT pub_name, stor_name
FROM (( (publishers JOIN titles ON publishers.pub_id=titles.pub_id) JOIN sales ON titles.title_id=sales.title_id) JOIN stores ON sales.stor_id=stores.stor_id)
GROUP BY pub_name, stor_name)












