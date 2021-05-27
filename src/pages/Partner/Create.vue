<template>
  <div class="q-pa-md">
    <q-stepper
      v-model="step"
      vertical
      color="primary"
      animated
    >
      <q-step
        :name="1"
        title="Заполните данные о партнере - Основная информация"
        icon="settings"
        caption="обязательно для заполнения"
        :done="step > 1"
      >
        <q-form
          class="q-gutter-md"
          @submit.prevent=""
          ref="companyData"
        >
          <q-input
            filled
            v-model="info.fullName"
            label="Полное название"
            hint="Полное название"
            lazy-rules
            dense
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

          <q-input
            filled
            v-model="info.workName"
            label="Сокращенное название"
            hint="Сокращенное название"
            lazy-rules
            dense
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

          <q-input
            filled
            v-model="info.relationship"
            label="Отношение с партнером"
            hint="Отношение с партнером"
            lazy-rules
            dense
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

          <q-input
            filled
            v-model="info.prefix"
            label="Префикс компании"
            hint="Используется для формирования документов"
            lazy-rules
            dense
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

          <q-input
            filled
            v-model="info.email"
            label="Email"
            hint="Email"
            lazy-rules
            dense
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

          <q-input
            filled
            v-model="info.phone"
            label="Контактный телефон"
            hint="Контактный телефон"
            lazy-rules
            dense
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />
        </q-form>

        <q-stepper-navigation>
          <q-btn @click="nextStep($refs.companyData, 2)" color="deep-orange" label="Далее" />
        </q-stepper-navigation>
      </q-step>

      <q-step
        :name="2"
        title="Заполните адресса компании"
        icon="create_new_folder"
        :done="step > 2"
      >
        <q-form
          class="q-gutter-md"
          @submit.prevent=""
          ref="companyAddress"
        >
          <q-input
            filled
            v-model="address.legalAddress"
            label="Введите юридический адрес компании"
            hint="Введите юридический адрес компании"
            lazy-rules
            dense
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />

          <q-input
            filled
            v-model="address.physicalAddress"
            label="Введите физический адрес компании"
            hint="Введите физический адрес компании"
            lazy-rules
            dense
            :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
          />
        </q-form>

        <q-stepper-navigation>
          <q-btn @click="onSubmit" color="deep-orange" label="Создать" />
          <q-btn flat @click="step = 1" color="primary" label="Назад" class="q-ml-sm" />
        </q-stepper-navigation>
      </q-step>

      <q-step
        :name="3"
        title="Выбор контрагентов"
        caption="обязательно для заполнения"
        icon="create_new_folder"
        :done="step > 3"
      >
        <q-form
          class="q-gutter-md"
          @submit.prevent=""
          ref="counterpatries"
        >
          <q-select
            filled
            v-model="selectedCounterparties"
            multiple
            dense
            :options="counterparties"
            label="Контрагенты"
            :value="item => item.name.workName"
            :option-label="item => item.name.workName"
            color="deep-orange"
          />

        </q-form>

        <q-stepper-navigation>
          <q-btn @click="onSubmitAdd" color="deep-orange" label="Добавить" :loading="loading" />
          <q-btn flat @click="step = 2" color="primary" label="Назад" class="q-ml-sm" :loading="loading" />
        </q-stepper-navigation>
      </q-step>

    </q-stepper>
  </div>
</template>

<script>
export default {
  name: 'CreatePartnerPage',
  data () {
    return {
      step: 1,
      loading: false,
      partnerId: null,
      info: {
        workName: null,
        fullName: null,
        email: null,
        phone: null,
        prefix: null,
        relationship: null
      },
      selectedCounterparties: [],
      address: {
        legalAddress: null,
        physicalAddress: null
      }
    }
  },
  computed: {
    counterparties () {
      return this.$store.state.counterparty.counterparties
    }
  },
  async mounted () {
    try {
      if (this.counterparties.length === 0) {
        await this.$store.dispatch('counterparty/fetchAll')
      }
    } catch (e) {
      this.$q.notify({
        type: 'negative',
        message: e.response.data
      })
    }
  },
  methods: {
    async onSubmitAdd () {
      try {
        this.loading = true
        const tins = []
        for (const key in this.selectedCounterparties) {
          tins.push(this.selectedCounterparties[key].tin)
        }

        const data = {
          counterparties: tins,
          partnerId: this.partnerId
        }
        const res = await this.$store.dispatch('partner/addCounterparty', data)
        if (res.status === 200) {
          this.$q.notify({
            type: 'positive',
            message: 'Контрагенты успешно добавлены'
          })
        }
      } catch (e) {
        this.$q.notify({
          type: 'negative',
          message: e.response.data
        })
      } finally {
        this.loading = false
      }
    },
    async onSubmit () {
      this.loading = true
      const form = new FormData()
      form.append('workName', this.info.workName)
      form.append('fullName', this.info.fullName)
      form.append('email', this.info.email)
      form.append('phone', this.info.phone)
      form.append('prefix', this.info.prefix)
      form.append('legalAddress', this.address.legalAddress)
      form.append('physicalAddress', this.address.physicalAddress)
      form.append('relationship', this.info.relationship)
      try {
        const res = await this.$store.dispatch('partner/create', form)
        if (res.status === 201) {
          this.nextStep(this.$refs.companyAddress, 3)
          this.partnerId = res.data.partnerId
          this.$q.notify({
            type: 'positive',
            message: 'Партнер успешно создан'
          })
        }
      } catch (e) {
        this.$q.notify({
          type: 'negative',
          message: e.response.data
        })
      } finally {
        this.loading = false
      }
    },
    nextStep (form, step) {
      form.validate().then(success => {
        if (success) {
          this.step = step
        }
      })
    }
  }
}
</script>
