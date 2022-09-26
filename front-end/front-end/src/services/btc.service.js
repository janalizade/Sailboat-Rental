export default {
  getLast31: () => fetch("https://api.coindesk.com/v1/bpi/historical/close.json?currency=EUR").then(res =>
    res.json()
  ),
  getCurrent: () => fetch("https://api.coindesk.com/v1/bpi/currentprice/EUR.json").then(res =>
    res.json()
  )
};
