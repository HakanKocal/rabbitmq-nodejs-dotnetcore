const amqp = require("amqplib/callback_api");



amqp.connect("amqp://localhost", function (err, conn) {
  if (err) throw err;
  conn.createChannel(function (err, channel) {
    var queue = "FirstQueue";
    channel.assertQueue(queue, {
      durable: false,
      autoDelete: false,
    });

    channel.consume(queue, (x) => {
      console.log(x.content.toString());

    });
  })
});