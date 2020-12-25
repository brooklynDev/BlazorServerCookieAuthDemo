export async function login(email, password) {
    const rawResponse = await fetch('/api/auth/login', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({email, password})
    });
    return await rawResponse.json();
}