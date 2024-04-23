import pkg from 'pg';
const { Pool } = pkg;

const pool = new Pool({
    user: "postgres",
    host: "localhost",
    database: "file_generator",
    password: "7592",
    port: 5432,
});

export default pool;
