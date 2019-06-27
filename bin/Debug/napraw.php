<?php
$file = 'products-3.csv';

$data = file_get_contents(__DIR__ . '/'. $file);
$data = str_replace('&quot;', "'", $data);
file_put_contents('products-new.csv', str_replace('&#039;', "'", html_entity_decode($data)));
// $rows = explode("\n", $data);

// foreach ($rows as $i => $row) {
// 	$column = explode(',', $row);
// 	$column[0] = str_replace('&#039;', "'", html_entity_decode($column[0]));
// 	$rows[$i] = implode($column, ',');

// 	file_put_contents('new_products.csv', $rows[$i]."\n", FILE_APPEND);
// }

