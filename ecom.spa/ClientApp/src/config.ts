const Config = {
  baseProductApiUrl: "http://localhost:5016",
  //baseProductApiUrl: "http://localhost:3501",
  baseOrderApiUrl: "http://localhost:5206",
};

const currencyFormatter = Intl.NumberFormat("en-US", {
  style: "currency",
  currency: "USD",
  maximumFractionDigits: 0,
});

export default Config;
export { currencyFormatter };
